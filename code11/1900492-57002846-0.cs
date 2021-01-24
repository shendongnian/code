using (Context context = new Context())
{
   var words = context.GetEntities<BaseDocument>().Where(e => e.Name.StartsWith("Word"));
   var excels = context.GetEntities<BaseDocument>().Where(e => e.Name.StartsWith("Excel"));
   var texts = context.GetEntities<BaseDocument>().Where(e => e.Name.StartsWith("Text"));
   baseDocuments = words.Concat(excels).Concat(texts);
}
