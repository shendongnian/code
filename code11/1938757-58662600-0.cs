    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Models;
    namespace WebApplication1.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ClientsController : ControllerBase
        {
            private readonly ClientContext _context;
    
            public ClientsController(ClientContext context)
            {
                _context = context;
            }
    
            // GET: api/Clients
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Client>>> GetClients()
            {
                return await _context.Clients.ToListAsync();
            }
    
            // GET: api/Clients/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Client>> GetClient(long id)
            {
                var client = await _context.Clients.FindAsync(id);
    
                if (client == null)
                {
                    return NotFound();
                }
    
                return client;
            }
    
            // PUT: api/Clients/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutClient(long id, Client client)
            {
                if (id != client.Id)
                {
                    return BadRequest();
                }
    
                _context.Entry(client).State = EntityState.Modified;
    
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
    
                return NoContent();
            }
    
            // POST: api/Clients
            [HttpPost]
            public async Task<ActionResult<Client>> PostClient(Client client)
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
    
                return CreatedAtAction("GetClient", new { id = client.Id }, client);
            }
    
            // DELETE: api/Clients/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<Client>> DeleteClient(long id)
            {
                var client = await _context.Clients.FindAsync(id);
                if (client == null)
                {
                    return NotFound();
                }
    
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
    
                return client;
            }
    
            private bool ClientExists(long id)
            {
                return _context.Clients.Any(e => e.Id == id);
            }
        }
    }
