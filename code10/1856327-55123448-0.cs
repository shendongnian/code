public returnObject PostFromThirdPartyObject([FromBody] ThirdPartyObject JSONobj)
{
    if(!ModelState.IsValid()) {
        // Do someting
    }
    // Process Object
    return returnObject;
}
