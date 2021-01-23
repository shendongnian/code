    	public class AdvancedTextBlock : TextBlock {
    		new private String Text { get; set; } //prevent text from being set as overrides all I do here.
    		private String _FormattedText = String.Empty;
    		public String FormattedText {
    			get { return _FormattedText; }
    			set { _FormattedText = value; AssignInlines(); }
    		}
    		private static Regex TagRegex = new Regex(@"\{(?<href>[^\|]+)\|?(?<text>[^}]+)?}", RegexOptions.Compiled);
    
    		public AdvancedTextBlock() : base() { }
    		public AdvancedTextBlock(System.Windows.Documents.Inline inline) : base(inline) { }
    
    		public void AssignInlines(){
    			this.Inlines.Clear();
    			Collection<Hyperlink> hyperlinks = new Collection<Hyperlink>();
    			Collection<String> replacements = new Collection<String>();
    			MatchCollection mcHrefs = TagRegex.Matches(FormattedText);
    			foreach (Match m in mcHrefs) {
    				replacements.Add(m.Value);
    				Hyperlink hp = new Hyperlink();
    				hp.NavigateUri = new Uri(m.Groups["href"].Value);
    				hp.Inlines.Add(m.Groups["text"].Success ? m.Groups["text"].Value : m.Groups["href"].Value);
    				hp.RequestNavigate += new RequestNavigateEventHandler(hp_RequestNavigate);
    				hyperlinks.Add(hp);
    			}
    			String[] sections = FormattedText.Split(replacements.ToArray(), StringSplitOptions.None);
    			hyperlinks.DefaultIfEmpty(null);
    			for (int i = 0, l = sections.Length; i < l; i++) {
    			    this.Inlines.Add(sections.ElementAt(i));
    				if (hyperlinks.ElementAtOrDefault(i) != null) {
    					this.Inlines.Add(hyperlinks[i]);
    				}
    			}
    		}
    
    		void hp_RequestNavigate(object sender, RequestNavigateEventArgs e) {
    			RequestNavigate(sender, e);
    		}
    
    		//
    		// Summary:
    		//     Occurs when navigation events are requested.
    		public event RequestNavigateEventHandler RequestNavigate;
    	}
