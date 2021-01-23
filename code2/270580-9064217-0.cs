        Thread.Sleep(240000);
                            errorMessage = string.Empty;
                            errorArticleIDList = new SortedList<string, string>();
                            if (GetSubmitFeedReport(feedSubmissionId, out errorMessage, out errorArticleIDList))
                            {
                                if (errorMessage != string.Empty)
                                {
                                    _log.ErrorFormat("FEHLER UpdateAmazonArticleStock: {0}", errorMessage);
                                }
                                foreach (AmazonArticleInfo amzArticle in rcavAmzArticleList)
                                {
                                    if (errorArticleIDList.Count > 0)
                                    {
                                        if (!errorArticleIDList.ContainsKey(amzArticle.ArticleID.ToString()))
                                        {
                                            // Die Artikelbestände von den relevanten Artikel aktuallisieren, bzw deaktivierte Artikel wieder aktivieren
                                            // Bestand = 0 --> deaktiviert
                                        if (!amzArticle.StockToLow && !amzArticle.NotAmazonRelevant)
                                            {
                                                amzArticle.AmazonActive = true;
                                            }
                                            // Alle nicht mehr relevanten Artikel in amazon deaktivieren
                                            else
                                            {
                                                amzArticle.AmazonActive = false;
                                            }
                                            dlAmazon.UpdateAmazonArticleAVDB(amzArticle);
                                        }
                                    }
                                    else
                                    {
                                        if (errorMessage == string.Empty)
                                        {
                                            dlAmazon.UpdateAmazonArticleAVDB(amzArticle);
                                        }
                                    }
                                }
                            }
