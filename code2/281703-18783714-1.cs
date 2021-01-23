            try
            {
                FileInfo n = new FileInfo(textBox1.Text);
                string initContent = File.ReadAllText(textBox1.Text);
                int contentLength = initContent.Length;
                Match m;
                while ((m = Regex.Match(initContent, "[^a-zA-Z0-9<>/\\s(&#\\d+;)-]")).Value != String.Empty)
                    initContent = initContent.Remove(m.Index, 1).Insert(m.Index, string.Format("&#{0};", (int)m.Value[0]));
            
                File.WriteAllText("outputpath", initContent);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            
            
        }
