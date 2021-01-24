c#
[UnitOfWork(isTransactional: false)]
public async Task<Guid> CreateAsync(InfoDto myInfo)
{
    int? tenantId = _unitOfWorkManager.Current.GetTenantId();
    objInfo = await _infoRepository.InsertAsync(myInfo);
    newObjId = CreateNewIdentifier(tenantId);
    objInfo.ExternalIdentifier = newObjId;
    // await _infoRepository.UpdateAsync(objInfo); // Remove this
    return objInfo.Id;
}
