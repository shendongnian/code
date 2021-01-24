        public class SQLGenerator : ISQLGenerator
        {
            ....
            public override string ToString()
            {
               return  $"{generatorModel.TableName} {generatorModel.Select}";
            }
    
        }
