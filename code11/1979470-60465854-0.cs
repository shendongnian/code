c#
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                Neuron n = new Neuron();                
            }
        }
    }
The function manager:
c#
    public delegate float NeuralFunction (params float[] inputs);
    public class FunctionManager
    {
        private static Random rand = new Random();
        private static FunctionManager singleton = new FunctionManager();
        private Dictionary<NeuralFunction,int> functionDict;
        private FunctionManager() {
            functionDict = new Dictionary<NeuralFunction, int>();
            functionDict.Add(Thresh, 1);
            functionDict.Add(Sum2, 2);
            functionDict.Add(Mul3, 3);
        }
        public static FunctionManager Singleton { get { return singleton; } }
        public float Sum2(params float[] inputs)
        {
            // 2 Inputs
            if (inputs.Length != 2)
                throw new InvalidOperationException();
            float n1 = inputs[0];
            float n2 = inputs[1];
            return n1 + n2;
        }
        public float Mul3(params float[] inputs)
        {
            // 3 Inputs
            if (inputs.Length != 3)
                throw new InvalidOperationException();
            float n1 = inputs[0];
            float n2 = inputs[1];
            float n3 = inputs[2];
            return n1 * n2 * n3;
        }
        public float Thresh(params float[] inputs)
        {
            // 1 Inputs
            if (inputs.Length != 1)
                throw new InvalidOperationException();
            float n1 = inputs[0];
            if (n1 > 0.5)
                return n1;
            return 0;
        }
        public KeyValuePair<NeuralFunction, int> GetRandomFunction()
        {                        
            List<NeuralFunction> keys = Enumerable.ToList(functionDict.Keys);            
            NeuralFunction function = keys[rand.Next(0, keys.Count)];
            return new KeyValuePair<NeuralFunction, int>(function, functionDict[function]);
        }
    }    
The neuron class:
c#
class Neuron
    {
        NeuralFunction function;
        int paramAmount;
        public Neuron()
        {
            KeyValuePair<NeuralFunction, int> keyVal = FunctionManager.Singleton.GetRandomFunction();
            function = keyVal.Key;
            paramAmount = keyVal.Value;
            MethodInfo method = function.Method;
            Console.WriteLine("-- Method: " + method.Name + "Has " + paramAmount + " Parameters");
        }
    }
