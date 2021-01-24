for(int i = 0; i < char_Data.Length; i++) {
    char_Data[i].GiveXP(XP.Types.Unarmed, 9000000);
    char_Data[i].GiveXP(XP.Types.Melee, 9000000);
    char_Data[i].GiveXP(XP.Types.Ranged, 9000000);
    char_Data[i].GiveXP(XP.Types.Acrobatic, 9000000);
    char_Data[i].myCash = 999999999;
}
