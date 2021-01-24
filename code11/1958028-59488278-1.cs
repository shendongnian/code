    public ImageController(IImageRepository imageRepository, IMapper mapper, 
        ITagRepository tagRepository, AppSettings settings) {
        
        _imageRepository = imageRepository;
        _tagRepository = tagRepository;
        _mapper = mapper;
    
        var imagesPath = settings.ImagesPath; //<--
    }
