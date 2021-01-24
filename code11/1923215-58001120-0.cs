//                           T                         TV
.Setup(b => b.HttpPost<CustomDataModelRequest, CustomDataModelResponse>(
  It.IsAny<string>(), 
  It.IsAny<CustomDataModelRequest>(), 
  null))
As well as passing a value for the optional parameter.
For the `Return` you can use:
.ReturnsAsync(new CustomDataModelResponse());
