    [ContentProperty("Items")]
    [MarkupExtensionReturnType(typeof(IEnumerable<Language>))]
    public class LanguageSelector : MarkupExtension {
        public LanguageSelector(string items) {
            Items = items;
        }
        [ConstructorArgument("items")]
        public string Items { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            string[] items = Items.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return new IEnumerableWrapper(items, serviceProvider);
        }
        class IEnumerableWrapper : IEnumerable<Language>, IEnumerator<Language> {
            string[] items;
            IServiceProvider serviceProvider;
            public IEnumerableWrapper(string[] items, IServiceProvider serviceProvider) {
                this.items = items;
                this.serviceProvider = serviceProvider;
            }
            public IEnumerator<Language> GetEnumerator() {
                return this;
            }
            int position = -1;
            public Language Current {
                get {
                    string name = items[position];
                    // TODO use any possible methods to resolve object by name
                    var rootProvider = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider
                    var nameScope = NameScope.GetNameScope(rootProvider.RootObject as DependencyObject);
                    return nameScope.FindName(name) as Language;
                }
            }
            public void Dispose() {
                Reset();
            }
            public bool MoveNext() { 
                return ++position < items.Length; 
            }
            public void Reset() { 
                position = -1; 
            }
            object IEnumerator.Current { get { return Current; } }
            IEnumerator IEnumerable.GetEnumerator() { return this; }
        }
    }
