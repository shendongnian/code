	Public string Documento
	{
		get
		{
			string nfse = FaturaContasReceberP?.NFSe?.NumeroNfse;
			string nfe = FaturaContasReceberP?.NotaFiscalProdutos;
			string documento = nfse ? $"Fat. NFSe: {nfse}" : "" +
							   nfe ? $" NFe: {nfe}";
			return documento.Trim();
		}
	}
