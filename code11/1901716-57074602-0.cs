     string tit0 = "Titulo 0";//Title strings to add to a Dictionary
     string tit1 = "Titulo 1";
     string tit2 = "Titulo 2";
     Dictionary<string, KeyValuePair<string, int>> indiceRelaciones = new Dictionary<string, KeyValuePair<string, int>>();
     indiceRelaciones=EscribirIndicePDF(innerDoc, DocPDF, tit0, indiceRelaciones);//HERE the title is added to the document and the dictionary flushed
     DocPDF.Add(parrafo1);//Paragraphs, tables and stuff
     DocPDF.Add(tabla1);
     DocPDF.Add(tabla2);
     indiceRelaciones = EscribirIndicePDF(innerDoc, DocPDF, tit1, indiceRelaciones);
     DocPDF.Add(parrafo2);
     indiceRelaciones = EscribirIndicePDF(innerDoc, DocPDF, tit2, indiceRelaciones);
     DocPDF.Add(parrafo3);
     crearIndice(innerDoc, DocPDF, indiceRelaciones);//This method generates the TOC
     DocPDF.Close();
     private static Dictionary<string, KeyValuePair<string, int>> EscribirIndicePDF(PdfDocument innerDoc, Document docPDF, string tit, Dictionary<string, KeyValuePair<string, int>> indice)
        {
            Paragraph titulo = new Paragraph().Add(new Text(tit));
            titulo.SetKeepTogether(true);
            outline = CreateOutline(outline, innerDoc, tit);
            KeyValuePair<string, int> paginaTitulo = new KeyValuePair<string, int>(tit, innerDoc.GetNumberOfPages());
            titulo.SetFontColor(ColorConstants.BLUE).SetDestination(tit).SetKeepWithNext(true).SetNextRenderer(new UpdatePageRenderer(titulo, paginaTitulo));
            docPDF.Add(titulo);
            indice.Add(tit, paginaTitulo);
            return indice;
        }
    private static void crearIndice(PdfDocument innerDoc, Document docPDF, Dictionary<string, KeyValuePair<string, int>> indiceRelaciones)
        {//¡Este método crea en la primera página el índice! Este no se toca. Se modifica el otro para que se llame y se agreguen entradas al diccionario.
            List<TabStop> tabStops = new List<TabStop>();
            tabStops.Add(new TabStop(580, TabAlignment.RIGHT, new DottedLine()));
            foreach (KeyValuePair<string, KeyValuePair<string, int>> entrada in indiceRelaciones) {
                KeyValuePair<string, int> texto = entrada.Value;
                string claveEntrada = entrada.Key;
                string claveTexto = texto.Key;
                string valorTexto = texto.Value.ToString();
                Paragraph p = new Paragraph().AddTabStops(tabStops).Add(claveTexto).Add(new Tab()).Add(valorTexto).SetAction(PdfAction.CreateGoTo(claveEntrada));
                docPDF.Add(p);
            }
        }
    private static PdfOutline CreateOutline(PdfOutline outline, PdfDocument innerDoc, string line)
        {
            if (outline == null)
            {
                outline = innerDoc.GetOutlines(false);
                outline = outline.AddOutline(line);
                outline.AddDestination(PdfDestination.MakeDestination(new PdfString(line)));
                return outline;
            }
            PdfOutline hijo = outline.AddOutline(line);
            hijo.AddDestination(PdfDestination.MakeDestination(new PdfString(line)));
            return outline;
        }
        internal class UpdatePageRenderer : ParagraphRenderer
    {
        private KeyValuePair<string, int> Entrada;
        public UpdatePageRenderer(Paragraph modelElement, KeyValuePair<string, int> entrada) : base(modelElement)
        {
            Entrada = entrada;
        }
        public override LayoutResult Layout(LayoutContext layoutContext)
        {
            LayoutResult result = base.Layout(layoutContext);
            int pagina = layoutContext.GetArea().GetPageNumber();
            Entrada = new KeyValuePair<string, int>(Entrada.Key, pagina);
            return result;
        }
    }
