                while (slideShowOn)
                {
                    if (this.Model.Images.Count < 1)
                    {
                        break;
                    }
                    var _bitmapsEnumerator = this.Model.Images.GetEnumerator();
                    try
                    {
                        while (_bitmapsEnumerator.MoveNext())
                        {
                            this.Model.SelectedImage = _bitmapsEnumerator.Current;
                            
                            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
                            Thread.Sleep(41);
                        }
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        if (ex.Message == "Collection was modified; enumeration operation may not execute.")
                        {
                        }
                        else throw ex;
                    }
                }
