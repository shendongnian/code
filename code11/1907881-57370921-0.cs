	private void selectNodeInEditor(SyntaxNode n) {
		var cm = (IComponentModel)Package.GetGlobalService(typeof(SComponentModel));
		var tm = (IVsTextManager)Package.GetGlobalService(typeof(SVsTextManager));
		var ws = (Workspace)cm.GetService<VisualStudioWorkspace>();
		var did = ws.CurrentSolution.GetDocumentId(n.SyntaxTree);
		ws.OpenDocument(did);
		tm.GetActiveView(1, null, out var av);
		var sp = n.GetLocation().GetMappedLineSpan().StartLinePosition;
		var ep = n.GetLocation().GetMappedLineSpan().EndLinePosition;
		av.SetSelection(sp.Line, sp.Character, ep.Line, ep.Character);
	}
