        private void ProcessPartialArrayInspectionOperations(IList<InspectionOperation> operations,
            int begin,
            int end,
            Inspection inspection,
            InspectionAsset inspectionAsset)
        {
            // create one new operation measuring point for each measuring point in the operation's equipment
            int itemCounter = begin + 1;
            for (int i = begin; i < end; i++)
            {
                InspectionOperation operation = operations[i];
                int itemNumber = 1;
                // get the asset
                InspectionAsset operationAsset = operation.OperationAsset;
                if (operationAsset != null)
                {
                    // get the measuring points
                    string ABAPTrue = Abap.ABAP_TRUE;
                    lock (_thisLock)
                    {
                        IList<MeasuringPoint> measuringPoints = DbContext.MeasuringPoints.Where(x =>
                                x.AssetID == operationAsset.AssetID && x.InactiveFlag != ABAPTrue)
                            .ToList();
                        if (measuringPoints != null)
                        {
                            //Debug.WriteLine("measuringPoints.Count = " + measuringPoints.Count);
                            // create the operation measuring points
                            foreach (MeasuringPoint measuringPoint in measuringPoints)
                            {
                                OperationMeasuringPoint operationMeasuringPoint =
                                    new OperationMeasuringPoint
                                    {
                                        InspectionID = inspection.InspectionID,
                                        OperationNumber = operation.OperationNumber,
                                        SubActivity = "",
                                        RoutingNo = "",
                                        ItemNumber = itemNumber.ToString("D4"),
                                        // e.g. "0001", "0002" and so on
                                        ItemCounter = itemCounter.ToString("D8"),
                                        // e.g. "00000001", "00000002" and so on
                                        MeasuringPointID = measuringPoint.MeasuringPointID,
                                        MeasuringPointDescription = measuringPoint.Description,
                                        Equipment = inspectionAsset.AssetID,
                                        Category = "P"
                                    };
                                DbContext.Entry(operationMeasuringPoint).State = EntityState.Added;
                                itemNumber++;
                                itemCounter++;
                            }
                        }
                    }
                }
            }
        }
                            Parallel.Invoke(
                                () => ProcessPartialArrayInspectionOperations(operations, 0, operations.Count / 2,
                                    inspection1, inspectionAsset),
                                () => ProcessPartialArrayInspectionOperations(operations, operations.Count / 2,
                                    operations.Count, inspection1, inspectionAsset)
                            );
