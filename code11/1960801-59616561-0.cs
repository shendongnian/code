CREATE TABLE [dbo].[TBUsers]
(
	[STT] [BIGINT] IDENTITY(1,1) NOT NULL,
	[HoTen] [NVARCHAR](MAX) NOT NULL,
	[MaSo] [NVARCHAR](50) NOT NULL,
	[MatKhau] [NVARCHAR](MAX) NOT NULL,
	[KhoaLop] [NVARCHAR](MAX) NOT NULL,
	[MaTheGui] [NVARCHAR](50) NOT NULL,
	[PhanQuyen] [INT] NOT NULL,
	[ChoPhepHoatDong] [BIT] NOT NULL,
	[NguoiThem] [NVARCHAR](MAX) NOT NULL,
	[NgayThem] [DATETIME] NOT NULL,
	[SoDuKhaDung] [BIGINT] NOT NULL,
	[DangGui] [BIT] NOT NULL,
	[TruyCapLanCuoi] [DATETIME] NULL,
	[ThoiGianGuiCuoi] [DATETIME] NULL,
	[HinhAnh] [IMAGE] NULL,
	[DonGia] [BIGINT] NULL,
    CONSTRAINT [PK_TBUsers] 
        PRIMARY KEY CLUSTERED ([MaTheGui] ASC)
                    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
                          IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
                          ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
**Step 1:** create a new class that corresponds to the table above and create 2 constructors, `Users`:
        public class Users
        {
            public Users()
            { }
            public Users(object sTT, object hoTen, object maSo, object matKhau, object khoaLop, object maTheGui, object phanQuyen, object choPhepHoatDong,
                object nguoiThem, object ngayThem, object soDuKhaDung, object dangGui, object truyCapLanCuoi, object thoiGianGuiCuoi, object hinhAnh,object donGia)
            {
                STT = sTT.ToString();
                HoTen = hoTen.ToString();
                MaSo = maSo.ToString();
                MatKhau = matKhau.ToString();
                KhoaLop = khoaLop.ToString();
                MaTheGui = maTheGui.ToString();
                PhanQuyen = phanQuyen.ToString();
                ChoPhepHoatDong = choPhepHoatDong.ToString();
                NguoiThem = nguoiThem.ToString();
                NgayThem = ngayThem.ToString();
                SoDuKhaDung = soDuKhaDung.ToString();
                DangGui = dangGui.ToString();
                TruyCapLanCuoi = truyCapLanCuoi.ToString();
                ThoiGianGuiCuoi = thoiGianGuiCuoi.ToString();
              
                HinhAnh = hinhAnh==System.DBNull.Value?null: (byte[])hinhAnh;
                DonGia = donGia.ToString();
                Color = (bool)choPhepHoatDong;
            }
            public string STT { get; set; }
            public string HoTen { get; set; }
            public string MaSo { get; set; }
            public string MatKhau { get; set; }
            public string KhoaLop { get; set; }
            public string MaTheGui { get; set; }
            public string PhanQuyen { get; set; }
            public string ChoPhepHoatDong { get; set; }
            public string NguoiThem { get; set; }
            public string NgayThem { get; set; }
            public string SoDuKhaDung { get; set; }
            public string DangGui { get; set; }
            public string TruyCapLanCuoi { get; set; }
            public string ThoiGianGuiCuoi { get; set; }
            public byte[] HinhAnh { get; set; }
            public string DonGia { get; set; }
            public bool Color { get; set; }
        }
    }
**Step 2:** Get `Users` from database with the `ParseUser` function:
        public static Users ParseUser(DataRow row)
        {
            var stt = row["STT"];
            var hoTen = row["HoTen"];
            var maSo = row["MaSo"];
            var matKhau = row["MatKhau"];
            var khoaLop = row["KhoaLop"];
            var maTheGui = row["MaTheGui"];
            var phanQuyen = row["PhanQuyen"];
            var choPhepHoatDong = row["ChoPhepHoatDong"];
            var nguoiThem = row["ChoPhepHoatDong"];
            var ngayThem = row["ChoPhepHoatDong"];
            var soDuKhaDung = row["SoDuKhaDung"];
            var dangGui = row["DangGui"];
            var truyCapLanCuoi = row["TruyCapLanCuoi"];
            var guiLanCuoi = row["ThoiGianGuiCuoi"];
            var hinhAnh = row["HinhAnh"] == System.DBNull.Value ? null : row["HinhAnh"];
            var donGia = row["DonGia"];
            return new Users(stt, hoTen, maSo, matKhau, khoaLop, maTheGui, phanQuyen, choPhepHoatDong, nguoiThem, ngayThem, soDuKhaDung, dangGui,
                truyCapLanCuoi, guiLanCuoi, hinhAnh, donGia);
        }
**Step 3:** Easily take an instance of Users class with `ParseUser` function:
Users user = ParseUser(sqlUtility.GetDataTable($"SELECT * FROM [dbo].[TBUsers] WHERE MaSo = 'xxx' AND ChoPhepHoatDong=1;").Rows[0]);
Similarly, you can create a class to retrieve the entire `Users` using any collection such as `List<User>` or `IEnumerable<User>`. You can use LinQ to query with this data.
