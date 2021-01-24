        AssetInformationDto information = new AssetInformationDto();
        AssetDto asset = _assetService.GetAssetById(id);
        AssetAvailabilityDto assetAvailability = _assetService.GetAssetAvailabilityByAssetId(id);
        IEnumerable<BookingScheduleDto> schedule = _assetService.GetAssetBookingSchedule(id, true);
        information = _mapper.Map<AssetInformationDto>(asset);
        information = _mapper.Map<AssetInformationDto>(assetAvailability);
        information = _mapper.Map<AssetInformationDto>(schedule);
