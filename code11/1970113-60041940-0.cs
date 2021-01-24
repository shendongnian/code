public Task OnReceiveAssociationRequestAsync(DicomAssociation association)
{
	foreach(var pc in association.PresentationContexts)
	{
		if(pc.AbstractSyntax == DicomUID.EncapsulatedPDFStorage)
		{
			pc.AcceptTransferSyntaxes(AcceptedImageTransferSyntaxes);
			pc.SetResult(DicomPresentationContextResult.Accept);
		}
		else
			pc.SetResult(DicomPresentationContextResult.RejectAbstractSyntaxNotSupported);
	}
	return SendAssociationAcceptAsync(association);
}
