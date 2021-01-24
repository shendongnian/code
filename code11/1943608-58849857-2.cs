        public class Fetch : IFetch 
        {
            private readonly IColorProvider _colorProvider;
            public Fetch(IColorProvider colorProvider)
            {
              _colorProvider = colorProvider
            }
            public string GetColorCodes() {
                 return _colorProvider.GetColor();
            }
            public string FetchData(){
            string  color= GetColorCodes();
            return color;
        }
