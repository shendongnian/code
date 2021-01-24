		public static MyEntitiesDbFirstModel MapToMyDbModel<T>(TrackingKeyStatic<T> trackingKey, IMapper mapper)
		{
			var interimTypeObject = new TrackingKey<T>()
            {
                NewTrackingKey = trackingKey.NewTrackingKey
            };
			
			var actual = mapper.Map<MyEntitiesDbFirstModel>(trackingKey);
			mapper.Map<ITrackingKey, MyEntitiesDbFirstModel>(interimTypeObject, actual);
			
			return actual;
		}	
