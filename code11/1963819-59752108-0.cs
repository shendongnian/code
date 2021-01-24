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
