csharp
using System;
using System.ComponentModel.DataAnnotations;
namespace Cardapio.Models
{
    public class Client
    {
        private DateTime createdAt;
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Identification { get; set; }
        public string Secrets { get; set; }
        public DateTime CreatedAt { get { return this.createdAt; } set { this.createdAt = DateTime.Now; } }
    }
}
You can minimise this however by assigning a default value to `CreatedAt` as there's nothing particularly custom happening in the `get` or `set` operations. If `CreatedAt` isn't expected to return from the API then you could also remove the `set`.
csharp
using System;
using System.ComponentModel.DataAnnotations;
namespace Cardapio.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Identification { get; set; }
        public string Secrets { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
