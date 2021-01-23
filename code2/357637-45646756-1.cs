    public class IdGeneratorConvention : ConventionBase, IPostProcessingConvention
    {
        public void PostProcess(BsonClassMap classMap)
        {
            var idMemberMap = classMap.IdMemberMap;
            if (idMemberMap == null || idMemberMap.IdGenerator != null)
            {
                return;
            }
            
            idMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
        }
    }
