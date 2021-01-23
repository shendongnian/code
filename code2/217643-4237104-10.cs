    public static ClassRoom ClassRoomOrNull(this School school)
    {
        return school == null ? null : school.ClassRoom;
    }
    public static Pupil PupilOrNull(this ClassRoom classRoom)
    {
        return classRoom == null ? null : classRoom.Pupil;
    }
    public static int? AgeOrNull(this Pupil pupil)
    {
        return pupil == null ? null : pupil.Age;
    }
