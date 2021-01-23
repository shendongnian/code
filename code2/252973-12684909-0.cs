    [HttpPost]
        public PartialViewResult DisplayGalleryThumbs(string galleryId)
        {
            int pageNumber = Convert.ToInt32(galleryId.Split('_')[2]);
            Guid feedId = new Guid(galleryId.Split('_')[1]);
            var images = _feedDomain.ShowPostById(feedId.ToString()).Images;
            int totalNumberOfPages = CountNumberOfPages(images);
            string action = galleryId.Split('_')[3];
            var dict = new Dictionary<int, List<FeedImage>>();
            var pagedImages = new List<FeedImage>();
            int i = 1;
            int a = 1;
            foreach (FeedImage image in images)
            {
                pagedImages.Add(image);
                if (i % NumberOfImagesPerPage == 0)
                {
                    dict.Add(a, pagedImages);
                    a++;
                    pagedImages=new List<FeedImage>();
                }
                if (i >= images.Count()) dict.Add(a, pagedImages);
                i++;
            }
            if (action=="next")
            {
                pageNumber += 1;
            }
            else
            {
                pageNumber -= 1;
            }
            
            var galleryModel = new FeedThumbGalleryModel
                                   {
                                       Images = dict.FirstOrDefault(c => c.Key == pageNumber).Value,
                                       FeedId = feedId,
                                       PageNumber = pageNumber,
                                       NumberOfPages = totalNumberOfPages,
                                       NumberOfImagesPerPage = NumberOfImagesPerPage,
                                       TotalNumberOfImages = images.Count()
                                   };
            return PartialView("~/Views/Feed/_DisplayGalleryThumbs.cshtml", galleryModel);
        }
    
    @helper Render(FeedThumbGalleryModel model)
{
    if (model.Images != null)
    {
        
        string linkNext = "linkNext_" + model.FeedId + "_" + model.PageNumber + "_next";
        string linkPrev = "linkPrev_" + model.FeedId + "_" + model.PageNumber + "_prev";
        
        string thumbFeedId = "feedThumbDiv_" + model.FeedId;
        <div id="@thumbFeedId">
            <table>
                <tr>
                    <td style="width: 30px;vertical-align: top;">
                        @if (model.NumberOfPages > 1)
                        {
                            if (model.PageNumber <= model.NumberOfPages && model.PageNumber > 1 || model.PageNumber == model.NumberOfPages)
                            {
                                <a class="page-action" href="#" id="@linkPrev">Prev</a>
                            }  
                        }
                    </td>
                    <td style="width: 120px;vertical-align: top">
                        @if (model.NumberOfPages>1)
                        {
                             for (int a = 1; a <= model.NumberOfPages; a++)
                             {
                                 int currentPage = a - 1;
                                 string pageLink = "linkNext_" + model.FeedId + "_" + currentPage + "_next";
                                 string classname = a==model.PageNumber ? "page-number-list" : "page-number-list1";
                                 
                                 <a href="#" id="@pageLink" class="@classname">@a</a>
                            }
                        }
                       
                    </td>
                    <td style="width: 220px;vertical-align: top;">
                            @if (model.PageNumber < model.NumberOfPages)
                            {
                                <a class="page-action" href="#" id="@linkNext">Next</a>
                            }
                    </td>
                    <td style="width: 150px;vertical-align: top;">
                        @{var thisId = "SeeAll_" + model.FeedId;}
                        @if (model.TotalNumberOfImages > 12)
                        {
                            <a id="@thisId" class="view-all">View All</a>
                        }
                        
                    </td>
                    <td style="vertical-align: top">
                        <div class="number-of-images">
                           @model.TotalNumberOfImages images  
                        </div>
                              
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <div style="width: 660px;padding-top: 10px">
                            @{int i = 1;}
                            @foreach (FeedImage m in model.Images)
                            {
                                string thumbThumb = ConfigurationManager.AppSettings["DisplayThumbPath"] + m.ImageId;
                                string imageUrl = "/feed/DisplayImage/" + model.FeedId + "_" + m.ImageId;
                          
                                <div class="thumbnail image">
                                    <a class='show-image' href="@imageUrl">
                                        <img border="0" class="image"  src="@thumbThumb" width="125" height="125" alt="" />
                                    </a>
                                </div>
                                            
                                if (i % model.NumberOfImagesPerPage == 0)
                                {
                                    break;
                                }
                                i++;
                            }
                            <br/>
                        </div>
                    </td>
             
                </tr>
            </table>
        </div>
        
    }
    
           
