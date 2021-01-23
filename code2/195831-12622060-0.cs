                        foreach (MenuItem item in MainMenu.Items[1].ChildItems)
                        {
                            if (item.ChildItems.Count != 0)
                                continue;
                            MainMenu.Items[1].ChildItems.Remove(item);
                            break;
                        }
                    }
                }
