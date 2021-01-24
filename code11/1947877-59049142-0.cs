    private static void OApplication_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            //Foo as your bool method
            if (Foo())
            {
                BubbleEvent = true;
            }
            else
            {
                BubbleEvent = false;
            }
        }
