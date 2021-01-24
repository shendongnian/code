        [HttpPost]
        [Route("Client/UpdateClient")]
        [Authorize]
        public ActionResult UpdateClient(ClientDTO client)
        {
            var user = GetLoggerUser(BOAccount);            
            client.LastModifiedBy = user.EmailAddress;
            client.LastModifiiedOn = DateTime.UtcNow;            
            var resultclient = BOClient.UpdateClient(client, user);
            return Json(resultclient);
        }
        // BOClient.UpdateClient
        public ClientDTO UpdateClient(ClientDTO client, UserDTO user)
        {
            var _clientRepo = ((UnitOfWork)_unitOfWork).ClientRepository;
            var _client = _clientRepo.Get(filter: u => u.Id == client.Id).Single();
    
            _client.Id = client.Id;
            _client.Phone = client.Phone;
            _client.Address = client.Address;
            _client.Email = client.Email;
            _client.Type = client.Type;
            _client.Name = client.Name;
    
            object _transaction = _unitOfWork.BeginTransaction();
            try
            {
                _clientRepo.Update(_client);
    
                _unitOfWork.CommitTransaction(_transaction);
            }
            catch (Exception)
            {
                _unitOfWork.RollbackTransaction(_transaction);
    
                return client;
            }
            finally
            {
                _unitOfWork.DestroyTransaction(_transaction);
            }
            return client;
        }
