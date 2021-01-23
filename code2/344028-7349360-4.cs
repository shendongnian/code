    public class KeyValuePairValueProviderFactory : ValueProviderFactory {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext) {
            return new KeyValuePairValueProvider(controllerContext.HttpContext.Request.Path);
        }
        private class KeyValuePairValueProvider : IValueProvider {
            private readonly Dictionary<String,String> _valuesDictionary = new Dictionary<String,String>();
            public bool ContainsPrefix(string prefix) {
                return true;
            }
            public KeyValuePairValueProvider(String rawUrl) {
                // The url have to be in this format
                // controller/key=value
                // controller/key=value/
                // controller/key=value?op=1
                // controller/key=value/?op=1
                // controller/action/key=value
                // controller/action/key=value?op=1
                // controller/action/key=value/?op=1
                // controller/action/key=value;key=value
                // controller/action/key=value;key=value?op=1
                // controller/action/key=value;key=value/?op=1
                String parameters = "";
                // removing the querystring
                if(rawUrl.Contains("?")){
                    // i split on the ? and take the first part
                    rawUrl = rawUrl.Split('?')[0];
                }
                
                // controller/key=value
                // controller/action/key=value
                // controller/action/key=value/
                // controller/action/key=value;key=value
                
                // check if the url without the querystring contains a = simbol
                // if yes I proceed into extract parameters
                if(rawUrl.Contains("=")){
                    // removing last slash
                    if (rawUrl.LastIndexOf('/')+1 == rawUrl.Length) {
                        rawUrl = rawUrl.Remove(rawUrl.LastIndexOf('/'));
                    }
                    int startIndex = rawUrl.LastIndexOf("/")+1;
                    int endIndex = rawUrl.Length;
                    int lenght = endIndex-startIndex;
                    parameters = rawUrl.Substring(startIndex,lenght);
                    String[] pairs = parameters.Split(';');
                    foreach (String pair in pairs) { 
                        String key = pair.Split('=')[0];
                        String value = pair.Split('=')[1];
                        _valuesDictionary.Add(key, value);
                    }
                }
            }
            public ValueProviderResult GetValue(string key) {
                if (_valuesDictionary.ContainsKey(key)) {
                    return new ValueProviderResult(
                        _valuesDictionary[key]
                        , _valuesDictionary[key]
                        , CultureInfo.CurrentUICulture);
                } else {
                    return null;
                }
            }
        }
    }
