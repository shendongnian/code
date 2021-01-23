     app.Flickr.PhotosSearchAsync(options, flickrResult =>
                {
                    if (flickrResult.HasError)
                    {                                          
                        ShowErrorImage();
                    }
                    else 
                    {                        
                        flickrPhotoUrls.Clear();
                        flickrImages.Clear();
                        foreach (var item in flickrResult.Result)
                        {
                            FlickrImage image = new FlickrImage();
                            image.ImageOwner = item.OwnerName;
                            image.DateTaken = item.DateTaken;
                            if (item.Title == string.Empty)
                            {
                                image.ImageTitle = "Untitled";
                            }
                            else
                            {
                                image.ImageTitle = item.Title;
                            }
                            image.SmallUrl = item.SmallUrl;
                            image.MediumUrl = item.MediumUrl;
                            image.Description = item.Description;
                            image.Latitude = item.Latitude;
                            image.Longitude = item.Longitude;
                            if (item.DoesLargeExist == true)
                            {
                                image.LargeUrl = item.LargeUrl;
                            }
                            flickrImages.Add(image);
                        }
                        ShowPhotos();
                    }                    
                });
