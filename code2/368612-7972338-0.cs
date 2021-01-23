    [WebInvoke(UriTemplate = "{EhrID}/PhysicalTest",Method="POST")] 
    public HttpResponseMessage<DTO.PhysicalTest> PostPhysicalTest(int EhrID, DTO.PhysicalTest PhysicalTestDTO) 
    { 
        var EHR = repository.FindById(EhrID); 
        var PhysicalTest = Mapper.Map<DTO.PhysicalTest, PhysicalTest>(PhysicalTestDTO); 
 
        if (PhysicalTest == null) 
        {                 
            var response = CreateResponseForException("No object to store", HttpStatusCode.BadRequest); 
            throw new HttpResponseException(response); 
        } 
 
        PostPhysicalTest(EHR, PhysicalTest);
        return new HttpResponseMessage<DTO.PhysicalTest>(PhysicalTestDTO, HttpStatusCode.Created);
    }
    private void PostPhysicalTest(EHR ehr, PhysicalTest physicalTest)
    {
        try 
        { 
            CreatePhysicalTest(ehr, physicalTest);
        } 
        catch (Exception ex) {                 
            var response = CreateResponseForException("Cannot create Physical Test", HttpStatusCode.InternalServerError); 
            throw new HttpResponseException(response); 
        }
    }
    private void CreatePhysicalTest(EHR ehr, PhysicalTest physicalTest)
    {
        if (ehr.PhysicalTests == null) 
        { 
            ehr.PhysicalTests = new List<PhysicalTest>(); 
        }
        physicalTest.CreationDate = DateTime.Now; 
        ehr.PhysicalTests.Add(physicalTest); 
        _unitOfWork.Commit();
    }
