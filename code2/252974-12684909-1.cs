    public class FeedImage
    {
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public double ImageSize { get; set; }
        public string FileExtension { get; set; }
        public string ImageType { get; set; }
        public FeedPost Post { get; set; }
        public List<FeedLike> Likes { get; set; }
        public List<FeedComment> Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public string DateCreatedIso8601 { get; set; }
    }
    private int CountNumberOfPages(List<FeedImage> images)
        {
            if (images == null) return 0;
            return (images.Count() + NumberOfImagesPerPage - 1) / NumberOfImagesPerPage;
        }
    $("[class='page-action']").live('click', function () {
        var feedArr = $(this).attr('id').split('_');
        var thisDivId = '#feedThumbDiv_' + feedArr[1];
        $.post('/Feed/DisplayGalleryThumbs', { galleryId: $(this).attr('id') },
                function (html) {
                    $(thisDivId).replaceWith(html);
                });
        return false;
    });
