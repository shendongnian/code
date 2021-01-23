            return Json(
                new
                {
                    files = new[]{
                                    new { 
                                            name = "www.png",
                                            type = "image/png" ,
                                            size = "1234567"
                                        }
                                  }
                }
            );
