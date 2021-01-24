    var getSliderImage = uow.Repository<SliderImage>().FindBy(x => x.SliderImageId == sliderImageId).FirstOrDefault();
    
    // get the file path based on getSliderImage.Image
    
    using (var stream = System.IO.File.OpenRead($"{filepath}"))
    {
        SliderImageVM newSliderImgeVM = new SliderImageVM
        {
            SliderImageId = getSliderImage.SliderImageId,
    
            Photo = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
        };
        
        // ...
        // code logic here
        // ...
    }
