       Left,
       Right
    }
    public enum IncomingOperatorType
    {
        LeftBracket,
        RighBracket,
        Plus,
        Minus,
        Multiply,
        Power,
        Divide ,
        FunctionArgumentSeprator,
        None
    }
    public class Operator
    {
        public Associativity Associativity { get; set; }
        public int Precedence { get; set; }
        public IncomingOperatorType OperatorType { get; set; }
    }
    public class ShuntingYard
    {
        private Stack<IncomingOperatorType> _stackOfOperators = new Stack<IncomingOperatorType>();
        private readonly Queue<string> _valueToAppend = new Queue<string>();
         private readonly Dictionary<IncomingOperatorType,Operator> _operatorsProperties = new Dictionary<IncomingOperatorType, Operator>();
        public ShuntingYard()
        {
            _operatorsProperties.Add(IncomingOperatorType.Power,
                new Operator
                     {  Associativity = Associativity.Right,
                        OperatorType = IncomingOperatorType.Power ,
                        Precedence = 4
                                                                        });
            _operatorsProperties.Add(IncomingOperatorType.Multiply, new Operator
            {
                Associativity = Associativity.Left,
                OperatorType = IncomingOperatorType.Multiply,
                Precedence = 3
            });
            _operatorsProperties.Add(IncomingOperatorType.Divide, new Operator
            {
                Associativity = Associativity.Left,
                OperatorType = IncomingOperatorType.Divide,
                Precedence = 3
            });
            _operatorsProperties.Add(IncomingOperatorType.Plus, new Operator
            {
                Associativity = Associativity.Left,
                OperatorType = IncomingOperatorType.Plus,
                Precedence = 2
            });
            _operatorsProperties.Add(IncomingOperatorType.Minus, new Operator
            {
                Associativity = Associativity.Left,
                OperatorType = IncomingOperatorType.Minus,
                Precedence = 2
            });
        }
        
        public Queue<string> CreatePostFixNotation(string inputInfixNotation)
        {
            var array = inputInfixNotation.Split(new[] {" ",""}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var inputChar in inputInfixNotation)
            {
                int parsedValue;
                var valueToBeParserd = inputChar.ToString();
                if (string.IsNullOrWhiteSpace(valueToBeParserd))
                    continue;
                if (int.TryParse(valueToBeParserd, out  parsedValue))
                {
                    _valueToAppend.Enqueue(valueToBeParserd); 
                }
                else
                {
                    var operatorType = ParseIncomingOperatorType(valueToBeParserd);
                    if(operatorType==IncomingOperatorType.FunctionArgumentSeprator)
                    {
                      while(!_stackOfOperators.Peek().
                          Equals(IncomingOperatorType.LeftBracket))
                      {
                          _valueToAppend.Enqueue(_stackOfOperators.Pop().ToString());
                          if (!_stackOfOperators.Any())
                              throw new ArgumentException(
                                  "either the separator was misplaced or parentheses were mismatched");
                      }
                    }
                    if (operatorType
                        == IncomingOperatorType.LeftBracket
                       )
                    {
                        _stackOfOperators.Push(operatorType);
                        continue;
                    }
                    if (operatorType
                        == IncomingOperatorType.RighBracket
                       )
                    {
                        while (!_stackOfOperators.Peek().
                          Equals(IncomingOperatorType.LeftBracket))
                        {
                            _valueToAppend.Enqueue(_stackOfOperators.Pop().ToString());
                        }
                        // pop  stack
                        var  currentItem =  _stackOfOperators.Pop();
                      
                        if(currentItem==IncomingOperatorType.FunctionArgumentSeprator)
                            _valueToAppend.Enqueue(_stackOfOperators.Pop().ToString());
                        continue;
                    }
                    if (operatorType 
                        != IncomingOperatorType.FunctionArgumentSeprator
                        || operatorType != IncomingOperatorType.None)
                    {
                        if (_stackOfOperators.Count > 0 )
                        {
                            while (_stackOfOperators.Count > 0 && _operatorsProperties.ContainsKey(operatorType) &&((_operatorsProperties[operatorType].Associativity == Associativity.Left &&
                                _operatorsProperties.ContainsKey(
                                        _stackOfOperators.Peek())&&
   
                                _operatorsProperties
                                        [_stackOfOperators.Peek()].Precedence >=
                                    _operatorsProperties[operatorType].Precedence)
                                   ||
                                   _operatorsProperties.ContainsKey(
                                        _stackOfOperators.Peek()) &&
                                   _operatorsProperties
                                       [_stackOfOperators.Peek()].Precedence >
                                   _operatorsProperties[operatorType].Precedence))
                            {
                                _valueToAppend.Enqueue(_stackOfOperators.Pop().ToString());
                                
                              
                            }
                            _stackOfOperators.Push(operatorType);
                           
                        }
                        else
                            _stackOfOperators.Push(operatorType);
                    }
                    
                }
            }
            if(_stackOfOperators.Any())
            {
                if(_stackOfOperators.Peek().Equals(IncomingOperatorType.LeftBracket)
                    ||_stackOfOperators.Peek().Equals(IncomingOperatorType.RighBracket) )
                    throw new ArgumentException(
                                  "there are mismatched parentheses.");
                while (_stackOfOperators.Any())
                {
                    _valueToAppend.Enqueue(_stackOfOperators.Pop().ToString()); 
                }
            }
            return _valueToAppend;
        }
        private IncomingOperatorType ParseIncomingOperatorType(string inputChar)
        {
            if (inputChar.Equals("("))
                return IncomingOperatorType.LeftBracket;
            if (inputChar.Equals(")"))
                return IncomingOperatorType.RighBracket;
            if (inputChar.Equals("+"))
                return IncomingOperatorType.Plus;
            if (inputChar.Equals("-"))
                return IncomingOperatorType.Minus;
            if (inputChar.Equals("*"))
                return IncomingOperatorType.Multiply;
            if (inputChar.Equals("/"))
                return IncomingOperatorType.Divide;
            if (inputChar.Equals(","))
                return IncomingOperatorType.FunctionArgumentSeprator;
            if (inputChar.Equals("^"))
                return IncomingOperatorType.Power;
           
            return IncomingOperatorType.None;
        }
    }
    public class TreeNode
    {
        public string data;
        public TreeNode LeftChild;
        public TreeNode RightChild;
    }
     var shuntingYard = new ShuntingYard();
            var output = shuntingYard.CreatePostFixNotation("((5+4)*6)-(3+(5*3))");
     
            var binaryTreeNodes = new Stack<TreeNode>();
            foreach (var str in output)
            {
                int parsedValue;
                if (int.TryParse(str, out  parsedValue))
                {
                  
                    binaryTreeNodes.Push(new TreeNode
                    {
                        data = str,
                    }); 
                }
                else
                {
                    binaryTreeNodes.Push(new TreeNode
                    {
                        data = str,
                        LeftChild = binaryTreeNodes.Pop(),
                        RightChild = binaryTreeNodes.Pop(),
                    }); 
                    
                }
            }
