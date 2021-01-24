                foreach(string item in files)
                {
                    string fullpath = path + item;
                    using (StreamReader reader = new StreamReader(fullpath))
                    {
                        bool firstLine = true;
                        while (!reader.EndOfStream)
                        {
                            if (firstLine)
                            {
                                firstLine = false;
                                continue;
                            }
                            string line = reader.ReadLine();
                            string productname = line.Split()[0];
                            float price = float.Parse(line.Split()[1]);
                            //check if product already in list (in case you have a new product in the 2nd or 3rd file you're reading)
                            if (!products.Exists(e => e.Equals(e.ProductCode == productname)))
                            {
                                products.Add(new Product() { ProductCode = productname , FirstPrice = price });
                            }
                            else
                            {
                                foreach(Product _product in products)
                                {
                                    if(_product.ProductCode == productname)
                                    {
                                        if(_product.SecondPrice == null)
                                        {
                                            _product.SecondPrice = price;
                                        }
                                        else
                                        {
                                            _product.ThirdPrice = price;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
