    public void AsynchFetchIntoListBox(ListBox listBox)
            {
                var wr = HttpWebRequest.Create("http://example.org");
                IAsyncResult ar = null;
                ar = wr.BeginGetResponse(_ =>
                    {
                        var r = wr.EndGetResponse(ar);
                        using (var s = new StreamReader(r.GetResponseStream()))
                        {
                            var result = s.ReadToEnd();
                            listBox.Invoke((Action)(() => 
                                listBox.Items.Add(result)));
                        }
                    } , null);
            }
