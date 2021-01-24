       public interface IColorProvider
       {
           string GetColor();
       }
       public class DefaultColorProvider : IColorProvider
       {
           public string GetColor => "Yellow";
       }
        public class Fetch : IFetch 
        {
            private readonly IColorProvider _colorProvider;
            public Fetch(IColorProvider colorProvider)
            {
              _colorProvider = colorProvider
            }
            public string FetchData(){
            string  color= _colorProvider.GetColor()
            return color;
        }       
