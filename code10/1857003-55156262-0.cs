    [HttpGet]
    [Route("CreateCardGroup")]
    public ActionResult CreateCardGroup()
    {
        PopulateCreateCardGroupLookups();
        return View();
    }
    [HttpPost]
    [Route("CreateCardGroup")]
    public ActionResult CreateCardGroup(CardGroupCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            PopulateCreateCardGroupLookups();
            return View(dto);
        }
        if(!UnitOfWork.DiscountPatternRepository
            .IsCardGroupDateInRange(dto.DiscountPatternId, 
             dto.ActiveFromDate, dto.ActiveToDate))
        {
            ModelState.AddModelError("ActiveFromDate", @"Error In Date.");
            PopulateCreateCardGroupLookups();
            return View(dto); <---Problem Here
        }
        var group = dto.LoadFrom();
        var insertedId = UnitOfWork.CardGroupRepository.Add(group);
        foreach (var rangeDto in group.CardGroupGiftSerialRanges)
        {
            for (var i = rangeDto.GiftCardSerialBegin; i <= 
                         rangeDto.GiftCardSerialEnd; i++)
            {
                var serial = 
                UnitOfWork.GiftCardSerialRepository.GetBySerial(i);
                if (serial != null)
                {
                    serial.CardGroupGiftSerialRangeId = rangeDto.Id;
                    serial.DiscountPatternId = group.DiscountPatternId;
                    UnitOfWork.Complete();
                }
            }
        }
        return Redirect("/CardGroup");
    }
    private void PopulateCreateCardGroupLookups()
    {
        var discounts = 
         UnitOfWork.DiscountPatternRepository.GetNotExpireDiscountPattern();
        var discountDtos = discounts?.Select(c => new SelectListItem
        {
            Text = c.PatternTitle,
            Value = c.Id.ToString()
        }).ToList();
        ViewData["DiscountPatterns"] = discountDtos;
        var serials = 
        UnitOfWork.ChargeCardSerialRepository.GetNotAssignedSerials();
        var serialDtos = serials?.Select(c => new SelectListItem
        {
            Text = c.SerialNumber.ToString(),
            Value = c.Id.ToString()
        }).ToList();
        ViewData["ChargeSerials"] = serialDtos;
        ViewData["CardSerialCount"] = 
        UnitOfWork.GiftCardSerialRepository.GetNotUsedGiftSerials();
    }
