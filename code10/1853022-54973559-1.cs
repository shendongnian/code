    	public enum FileMIME
		{
			Document,
			Photos,
			Video		
		}
        public class APIResponse
		{
			private List<APIFile> _photos;
			[JsonProperty(PropertyName = "Photos")]
			public List<APIFile> Photos
			{
				get { return _photos; }
				set {	_photos = value;
						foreach(var photo in _photos)
						{
							photo.MIMEType = FileMIME.Photos;
						}
					}
			}
			private APIFile _document;
			[JsonProperty(PropertyName = "Document")]
			public APIFile Document
			{
				get { return _document; }
				set { _document = value; _document.MIMEType = FileMIME.Document; }
			}
			private APIFile _video;
			[JsonProperty(PropertyName = "Video")]
			public APIFile Video
			{
				get { return _video; }
				set { _video = value; _video.MIMEType = FileMIME.Video; }
			}
		}
