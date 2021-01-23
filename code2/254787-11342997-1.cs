    //Abstract factory
    abstract class ComputerFactory
    {
        public abstract Computer BuildComputer(Computer.ComputerType compType);
    }
    public class ConcreteFactory : ComputerFactory
    {
        public override Computer BuildComputer(Computer.ComputerType compType)
        {
            if (compType == Computer.ComputerType.xps)
                return (new xps());
            else if (compType == Computer.ComputerType.inspiron)
                return new inspiron();
            else if (compType == Computer.ComputerType.envoy)
                return (new envoy());
            else if (compType == Computer.ComputerType.presario)
                return new presario();
            else
                return null;
        }
    }
    
    //Abstract product
    public abstract class Computer
    {
        public abstract string Mhz { get; set; }
        public enum ComputerType
        {
            xps,
            inspiron,
            envoy,
            presario
        }
    }
    //Concrete product for DELL
    public class xps : Computer
    {
        string _mhz = string.Empty;
        public override string Mhz
        {
            get
            {
                return _mhz;
            }
            set
            {
                _mhz = value;
            }
        }
    }
    //Concrete product for DELL
    public class inspiron : Computer
    {
        string _mhz = string.Empty;
        public override string Mhz
        {
            get
            {
                return _mhz;
            }
            set
            {
                _mhz = value;
            }
        }
    }
    //Concrete product for HP
    public class envoy : Computer
    {
        string _mhz = string.Empty;
        public override string Mhz
        {
            get
            {
                return _mhz;
            }
            set
            {
                _mhz = value;
            }
        }
    }
    //Concrete product for HP
    public class presario : Computer
    {
        string _mhz = string.Empty;
        public override string Mhz
        {
            get
            {
                return _mhz;
            }
            set
            {
                _mhz = value;
            }
        }
    }
    public class BestBuy
    {        
        ConcreteFactory compFactory;
        Computer comp;
        public BestBuy(Computer.ComputerType compType)
        {
            comp = compFactory.BuildComputer(compType);            
        }
        public Computer Sell()
        {
            return comp;
        }
    }
