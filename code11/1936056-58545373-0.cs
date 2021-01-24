cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
namespace FightClubApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectMayhemController : ControllerBase
    {
        [HttpGet]
        public Member Get() => new Member
        {
            Name = "Robert Paulson",
            Code = ASCIIEncoding.ASCII.GetBytes("His name was Robert Paulson")
                                      .ToList()
        };
    }
    public class Member
    {
        public string Name { get; set; }
        public List<byte> Code { get; set; }
    }
}
Hitting that API endpoint (using GET https://localhost:5001/api/ProjectMayhem) returns the following JSON:
json
{
  "name": "Robert Paulson",
  "code": [
    72, 105, 115, 32, 110, 97, 109, 101, 32, 119, 97, 115, 32, 82, 111, 98, 101, 114, 116, 32, 80, 97, 117, 108, 115, 111, 110
  ]
}
I would just need to cast it to an `Uint8Array`.
