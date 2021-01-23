            private void runner(int i)
        {
            int j = i;
            bool loadFinished = false;
            webBrowser1.DocumentCompleted += delegate { loadFinished = true; };
            webBrowser1.Navigate("http://www11.itrc.hp.com/service/ewarranty/warrantyInput.do");
            while (!loadFinished )
            {
                Thread.Sleep(100);
                Application.DoEvents();
            }
            
            webBrowser1.Document.GetElementById("productnumber").InnerText = dt.Rows[j][0].ToString();
            webBrowser1.Document.GetElementById("serialnumber1").InnerText = dt.Rows[j][1].ToString();
            HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("SELECT");
            foreach (HtmlElement elem in elems)
            {
                if (elem.Name.ToString() == "country")
                {
                    elem.SetAttribute("value", "US");
                }
            }
            int countelement = 0;
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("INPUT");
            foreach (HtmlElement element in col)
            {
                if (element.Name.ToString() == "")
                {
                    if (countelement == 1)
                    {
                        element.InvokeMember("click");
                        do
                        {
                            Application.DoEvents();
                        } while (webBrowser1.IsBusy);
                    }
                    countelement++;
                }
            }
            string output = "";
            int county = 0;
            HtmlElementCollection elly = webBrowser1.Document.GetElementsByTagName("TABLE");
            foreach (HtmlElement el in elly)
            {
                if (county == 19)
                {
                    string[] lines = el.InnerText.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        if (line.IndexOf("Start Date") != -1)
                        {
                            output = line.ToString();
                            dt.Rows[j][2] = output.Remove(0, 10);
                            break;
                        }
                    }
                    
                }
                county++;
            }
        }
