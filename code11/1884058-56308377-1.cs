    public class ElapsedTimeJsonConverter : JsonConverter<ElapsedTime>
        {
            public override ElapsedTime ReadJson(JsonReader reader, Type objectType, ElapsedTime existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                if (!DateTime.TryParse(reader.ReadAsString(), out var date))
                    return ElapsedTime.Unknown;
    
                var elapsedTime = default(ElapsedTime);
                var timeDifference = date.Subtract(DateTime.Now).TotalMinutes;
    
                if (timeDifference < 1)
                {
                    elapsedTime = ElapsedTime.SomeSeconds;
                }
                else if (timeDifference >= 1 && timeDifference < 10)
                {
                    elapsedTime = ElapsedTime.LessThanTenMinutes;
                }
                else if (timeDifference >= 10 && timeDifference < 30)
                {
                    elapsedTime = ElapsedTime.LessThanThirtyMinutes;
                }
                else if (timeDifference >= 30 && timeDifference < 60)
                {
                    elapsedTime = ElapsedTime.LessThanAnHour;
                }
                else if (timeDifference >= 60)
                {
                    elapsedTime = ElapsedTime.MoreThanAnHour;
                }
    
                return elapsedTime;
    
            }
    
            public override void WriteJson(JsonWriter writer, ElapsedTime value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
