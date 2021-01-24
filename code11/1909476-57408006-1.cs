        AssetInformationDto information = new AssetInformationDto();
        AssetDto asset = _assetService.GetAssetById(id);
        AssetAvailabilityDto assetAvailability =
		_assetService.GetAssetAvailabilityByAssetId(id);
        IEnumerable<BookingScheduleDto> schedule =
		_assetService.GetAssetBookingSchedule(id, true);
		information = _mapper.Map<AssetInformationDto>(asset);
        _mapper.Map(assetAvailability, information);
        _mapper.Map(schedule, information);
