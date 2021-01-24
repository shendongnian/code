internal class MyDefectTagger : ITagger<MyDefectTag>
{
	private IClassifier m_classifier;
	private ITextBuffer m_buffer;
	internal MyDefectTagger(IClassifier classifier, ITextBuffer buffer)
	{
		m_classifier = classifier;
		m_buffer = buffer;
	}
	IEnumerable<ITagSpan<MyDefectTag>>
        ITagger<MyDefectTag>.GetTags(NormalizedSnapshotSpanCollection spans)
	{
		if (MyModel.Instance == null || MyModel.Instance.defectsLocation == null)
		{
			yield return null;
		}
		var filename = GetFileName(m_buffer);
		if (!MyModel.Instance.defectsLocation.ContainsKey(filename))
		{
			yield return null;
		}
		foreach (SnapshotSpan span in spans)
		{
			ITextSnapshot textSnapshot = span.Snapshot;
			foreach (ITextSnapshotLine textSnapshotLine in textSnapshot.Lines)
			{
				var line = textSnapshotLine.LineNumber + 1; // Lines start at 1 in VS Editor
				if (MyModel.Instance.defectsLocation[filename].ContainsKey(line) &&
					!MyModel.Instance.defectsLocation[filename][line].rendered)
				{
					var rendered = MyModel.Instance.defectsLocation[filename][line].rendered;
					yield return new TagSpan<MyDefectTag>(
                        new SnapshotSpan(textSnapshotLine.Start, 0),
                        new MyDefectTag()
                    );
				}
			}
		}
	}
}
