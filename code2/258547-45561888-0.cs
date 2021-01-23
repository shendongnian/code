     if (MyModal.ImageFile != null)
                        {
                            MyModal.ImageURL = string.Format("{0}.{1}", Guid.NewGuid().ToString(), MyModal.ImageFile.FileName.Split('.').LastOrDefault());
                            if (MyModal.ImageFile != null)
                            {
                                var path = Path.Combine(Server.MapPath("~/Content/uploads/"), MyModal.ImageURL);
                                MyModal.ImageFile.SaveAs(path);
                            }
                        }
