cs
var efEntity = context.Model.FindEntityType(typeof(T));
var efProperties = efEntity.GetProperties();
var hasIdentity = efProperties.Any(p => (SqlServerValueGenerationStrategy)
    p.FindAnnotation("SqlServer:ValueGenerationStrategy").Value
    == SqlServerValueGenerationStrategy.IdentityColumn);
var identityProperty = efProperties.FirstOrDefault(p => (SqlServerValueGenerationStrategy)
    p.FindAnnotation("SqlServer:ValueGenerationStrategy").Value
    == SqlServerValueGenerationStrategy.IdentityColumn);
With libraries:
cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
