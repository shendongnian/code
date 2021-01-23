        public static WIA.Device SelectCamera() {
            var dlg = new WIA.CommonDialog();
            try {
                return dlg.ShowSelectDevice(WIA.WiaDeviceType.CameraDeviceType, false, false);
            }
            catch (System.Runtime.InteropServices.COMException ex) {
                if (ex.ErrorCode == -2145320939) return null;
                throw;
            }
        }
