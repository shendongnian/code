    abstract class Operation {
        public abstract bool DoOperation(bool left, bool right);
    }
    
    class OrOperation {
        public override bool DoOperation(bool left, bool right) {
            return left || right;
        }
    }
    
    class DoOperationStuff {
        Dictionary<string, Operation> mappedObjects = new Dictionary<string, Operation>() {
            {"OR", new OrOperation()}
        };
        
        public bool resultOfOperation(bool left, bool right, string operation) {
            if(mappedObjects.ContainsKey(operation)) {
                return mappedObjects[operation].DoOperation(left, right);
            }
            
            throw new ArgumentException("Something has gone very wrong.");
        }
    }
