    public static class Program{
            
            static string VsanString = 
    @"vsan 1 interfaces:
    fc2/1             
    vsan 10 interfaces:
    fc1/1             fc1/2             fc1/3             fc1/4             
    fc1/5             fc1/6             fc1/7             fc1/8             
    fc1/9             fc1/10            fc1/11            fc1/12            
    fc1/13            fc1/14            fc1/15            fc1/16    ";
    
            public static void Main (string[] args) {
    
                VSanTokenizer vSanTokenizer = new VSanTokenizer(VsanString);
                IList<IToken> tokens = vSanTokenizer.Tokens;
                VsanTokenInterpreter vsanTokenInterpreter = new VsanTokenInterpreter(tokens);
                IList<IVSan> vSans = vsanTokenInterpreter.VSans;
                foreach (IVSan vSan in vSans) {
                    Console.WriteLine(vSan.ToString());
                }
                Console.WriteLine("Please press return to quit.");
                Console.ReadLine();
            }
        }
    
        interface IVSan {
            int Number { get; }
            IList<IInterface> Interfaces { get; }
        }
    
        class VSan : IVSan {
            private readonly IList<IInterface> interfaces;
            private readonly int number;
    
            public VSan(int number, IList<IInterface> interfaces) {
                this.number = number;
                this.interfaces = interfaces;
            }
    
            public override string  ToString() {
                
                StringBuilder toString = new StringBuilder();
    
                toString.Append("Vsan with Number: ");
                toString.Append(number);
                toString.Append(" has following Interfaces:");
                toString.AppendLine("");
    
                foreach (IInterface @interface in Interfaces) {
                    toString.Append("Intefaces with Name: ");
                    toString.Append(@interface.Name);
                    toString.AppendLine("");
                }
                return toString.ToString();
            }
    
            #region Implementation of IVSan
    
            public int Number {
                get { return number; }
            }
    
            public IList<IInterface> Interfaces {
                get { return interfaces; }
            }
    
            #endregion
        }
    
    
        interface IInterface {
            string Name { get; }
        }
    
        class Interface : IInterface {
            private readonly string name;
    
            public Interface(string name) {
                this.name = name;
            }
    
            #region Implementation of IInterface
    
            public string Name {
                get { return name; }
            }
    
            #endregion
        }
    
        interface IToken {
            string Value { get; }
        }
    
        interface IVsanToken : IToken {
            int VsanInterfaceNumber { get; }
        }
    
        internal abstract class AbstractToken : IToken {
            private readonly string value;
    
            public AbstractToken(string value) {
                this.value = value;
            }
    
            #region Implementation of IToken
    
            public string Value {
                get { return value; }
            }
    
            #endregion
        }
    
        class VsanToken : AbstractToken, IVsanToken {
    
            private readonly int vsanInterfaceNumber;
    
            public VsanToken(string value)
                : base(value) {
                vsanInterfaceNumber = int.Parse(value);
            }
    
            #region Implementation of IVsanToken
    
            public int VsanInterfaceNumber {
                get { return vsanInterfaceNumber; }
            }
    
            #endregion
        }
    
        class InterfaceToken : AbstractToken, IInterfaceToken {
    
            private readonly int firstNumber;
            private readonly int secondNumber;
    
            public InterfaceToken(string value)
                : base(value) {
    
                Match match = Regex.Match(value, "fc([0-9])/([0-9]+)");
                Group firstNumberGroup = match.Groups[1];
                Group secondNumberGroup = match.Groups[2];
    
                firstNumber = int.Parse(firstNumberGroup.Value);
                secondNumber = int.Parse(secondNumberGroup.Value);
            }
    
            public int SecondNumber {
                get { return secondNumber; }
            }
    
            public int FirstNumber {
                get { return firstNumber; }
            }
        }
    
        interface IInterfaceToken : IToken {
            //Edited: Added Second and FirstNumber to Interface so it can be accessed
            int SecondNumber { get; }
            int FirstNumber { get ; }
        }
    
        class VSanTokenizer {
            private readonly string vSanString;
            private IList<IToken> tokens;
    
            public VSanTokenizer(string vSanString) {
                this.vSanString = vSanString;
                tokens = Tokenize(vSanString);
            }
    
            public string VSanString {
                get { return vSanString; }
            }
    
            private IList<IToken> Tokenize(string vSanString) {
                List<IToken> tokens = new List<IToken>();
                StringReader reader = new StringReader(vSanString);
                string readLine = reader.ReadLine();
                while (readLine != null) {
                    IList<IToken> tokenizeLine = TokenizeLine(readLine);
                    tokens.AddRange(tokenizeLine);
                    readLine = reader.ReadLine();
                }
                return tokens;
            }
    
            private IList<IToken> TokenizeLine(string readLine) {
                IList<IToken> tokens = new List<IToken>();
                Match vsanInterfaceDeclartion = Regex.Match(readLine, "vsan ([0-9]+) interfaces:");
                if (vsanInterfaceDeclartion.Success) {
                    Group numberGroup = vsanInterfaceDeclartion.Groups[1];
                    VsanToken vsanToken = new VsanToken(numberGroup.Value);
                    tokens.Add(vsanToken);
                    return tokens;
                }
    
                Match vsanInterface = Regex.Match(readLine, "(fc[0-9]/[0-9]+)");
                if (vsanInterface.Success) {
                    GroupCollection groupCollection = vsanInterface.Groups;
                    foreach (Group vsanInterfaceGroup in groupCollection) {
                        string value = vsanInterfaceGroup.Value;
                        IToken token = new InterfaceToken(value);
                        tokens.Add(token);
                    }
                }
    
                return tokens;
            }
    
            public IList<IToken> Tokens {
                get {
                    return tokens;
                }
            }
        }
    
        class VsanTokenInterpreter {
            private readonly IList<IToken> tokens;
            private readonly IList<IVSan> vSans;
    
            public VsanTokenInterpreter(IList<IToken> tokens) {
                this.tokens = tokens;
    
                this.vSans = ParseTokens(tokens);
            }
    
            private IList<IVSan> ParseTokens(IList<IToken> tokens) {
                IList<IVSan> vsans = new List<IVSan>();
    
                IVSan currentVSan = null;
                foreach (IToken token in tokens) {
                    if (token is IVsanToken) {
                        currentVSan = CreateVSan((IVsanToken)token);
                        vsans.Add(currentVSan);
                    } else if (token is IInterfaceToken) {
                        if (currentVSan == null)
                            throw new Exception("First Vsan Line has to be declared!");
                        IInterface inter = CreateInterface((IInterfaceToken)token);
                        
                        currentVSan.Interfaces.Add(inter);
                    }
                }
    
                return vsans;
            }
    
            protected virtual IInterface CreateInterface(IInterfaceToken interfaceToken) {
                //Edited: you can now access the First/Second Number from the Interface Token and use it to create the Instance of your interface:
                int firstNumber = interfaceToken.FirstNumber;
                int secondNumber = interfaceToken.SecondNumber;
                return new Interface(interfaceToken.Value);
    
            }
    
            protected virtual IVSan CreateVSan(IVsanToken vsanToken) {
                return new VSan(vsanToken.VsanInterfaceNumber, new List<IInterface>());
    
            }
    
            public IList<IVSan> VSans {
                get { return vSans; }
            }
    
            public IList<IToken> Tokens {
                get { return tokens; }
            }
        }
