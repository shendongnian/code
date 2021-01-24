public Task OnReceiveAssociationRequestAsync(DicomAssociation association)
{
	foreach(var pc in association.PresentationContexts)
	{
		if(pc.AbstractSyntax == DicomUID.EncapsulatedPDFStorage)
			pc.SetResult(DicomPresentationContextResult.RejectAbstractSyntaxNotSupported);
		else
		{
			pc.AcceptTransferSyntaxes(AcceptedImageTransferSyntaxes);
			pc.SetResult(DicomPresentationContextResult.Accept);
		}
	}
	return SendAssociationAcceptAsync(association);
}
The `DicomAssociation association` is ASSOCIATION_REQUEST you received. The `association.PresentationContexts` holds all proposed Presentation Contexts in received association. You enumerate through each of it. Each proposed Presentation Context contain Abstract Syntax and list of proposed Transfer Syntaxes. You can loop through list of transfer syntaxes and set the one you prefer; as your question is not about it, I skipped that part in code.
If you can accept (receive/process) the pair of Abstract Syntax and Transfer Syntax that is proposed, you accept that specific Presentation Context by setting its result. If you don't, set the result accordingly with reason.
Finally, send the ASSOCIATE_ACCEPT (or reject...).
