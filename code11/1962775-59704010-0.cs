                        switch (contentEncoding?.Item2.ToLower() ?? String.Empty)
                        {
                            case "":
                                bodyPlain = UTF8Encoding.UTF8.GetString(ret);
                                break;
                            case "gzip":
                                bodyPlain = Tools.Gunzip(ret);
                                break;
                            case "deflate":
                                bodyPlain = Tools.Decompress(ret);
                                break;
                        }
