    private Task<InfoModel> getInfoAsync() {
        InfoModel model = new InfoModel();
        //Do async work
        return model;
    }
    [HttpGet("GetInfo")]
    public async Task<ActionResult<InfoModel>> GetInfo() {
        InfoModel model = await getInfoAsync();
        //and additional work needed specific to this request
        return model;
    }
    [HttpPost("GetOtherInfo")]
    public async Task<ActionResult<NewModel>> GetOtherInfo(RequestInfoModel req) {
        NewModel ret = new NewModel();
        //Do some work
        //Need some info data
        InfoModel im1 = await getInfoAsync();
        //Do work with im1
        return ret;
    }
