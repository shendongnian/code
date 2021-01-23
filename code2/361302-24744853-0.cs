    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <SnippetTypes>
            <SnippetType>SurroundsWith</SnippetType>
          </SnippetTypes>
          <Title>ValidationErrorsTryCatch</Title>
          <Author>Phoenix</Author>
          <Description>
          </Description>
          <HelpUrl>
          </HelpUrl>
          <Shortcut>
          </Shortcut>
        </Header>
        <Snippet>
          <Code Language="csharp"><![CDATA[try
    {
        $selected$ $end$
    }
    catch (System.Data.Entity.Validation.DbEntityValidationException e)
    {
        foreach (var eve in e.EntityValidationErrors)
        {
            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                eve.Entry.Entity.GetType().Name, eve.Entry.State);
            foreach (var ve in eve.ValidationErrors)
            {
                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    ve.PropertyName, ve.ErrorMessage);
            }
        }
        throw;
    }]]></Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
