    public interface ILoad
    {
    }
    public abstract class LoaderBase : ILoad
    {
        public abstract void Load(string path);
    }
    public class InstanceChooser
    {
        private InstanceChooser()
        {
        }
        //construction and initialization
        public static ILoad Create(string path)
        {
            InstanceChooser myChooser = new InstanceChooser();
            LoaderBase myLoader = myChooser.Choose(path);
            if (myLoader != null)
            {
                myLoader.Load(path); //virtual method call moved out of constructor.
            }
            return myLoader;
        }
        //construction
        private LoaderBase Choose(string path)
        {
            switch (System.IO.Path.GetExtension(path))
            {
                case "z":  //example constructor call
                    return new CompiledLoaderV1(this);
            }
            return null;
        }
    }
    public class CompiledLoaderV1 : LoaderBase
    {
        public CompiledLoaderV1(InstanceChooser dongle)
            : base()
        {
        }
        public override void Load(string path)
        {
            throw new NotImplementedException();
        }
    }
