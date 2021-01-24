public async Task<JsonResult> SaveSetting([FromBody] Filter<JObject> model)
{
    Type filterRequestModelType = this.DetermineSafeModelType(model);
    object typedFilterRequestModel = model.FilterRequestModel.ToObject(filterRequestModelType);
    return SaveSettingHelper(model, (dynamic) typedFilterRequestModel);
}
public async Task<JsonResult> SaveSetting<T>([FromBody] Filter<JObject> model, T filterRequestModel) {...}
