    public sealed class SyntaxService : ISyntaxService
	{
		public SyntaxService(IParser parser, ILexicon lexicon)
		{
			m_parser = parser;
			m_lexicon = lexicon;
			
			// These are the setting I needed, YMMV.  They seem to add a lot of UI logic to this method :(
			m_processingResources = new ProcessingResources(m_lexicon, null, null, m_parser, 5, null, false, null, null, null, null, false);
		}
		public IEnumerable<Sentence> GetSentences(string s)
		{
			IDocument document = new Document(s, m_processingResources);
			
			return document.Select(Mappers.SentenceMapper.Map);
		}
		readonly IParser m_parser;
		readonly ILexicon m_lexicon;
		readonly IProcessingResources m_processingResources;
	}
