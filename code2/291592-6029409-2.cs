    public class Processor1 : IProcessor {
        public bool CanProcess(InputEntity entity) {
            return entity.Field == "field1";
        }
    }
