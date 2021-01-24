    private DataManager _manager;
    
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagedTransactionDataRequest queryParams)
        {
            var pageSize = queryParams.PageSize ?? 1;
            var pageNumber = queryParams.PageNumber ?? 10;
    
    if(_manager == null) {_manager = new DataManager(async () =>
            await _paymentDraftHub.Clients.All.SendAsync(SignalRConstants.TransferPaymentDraftServiceData, await _paymentTransactionRepository.GetAllDeclinedAsync(pageSize, pageNumber))
            );
    }
    else
    {_manager.action = async () => await _paymentDraftHub.Clients.All.SendAsync(SignalRConstants.TransferPaymentDraftServiceData, await _paymentTransactionRepository.GetAllDeclinedAsync(pageSize, pageNumber));
    }
    
            var response = new ResponseMessage { Message = "Accepted", Code = "201" };
            return Ok(response);
        }
