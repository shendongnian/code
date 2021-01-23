    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.IO;
    
    namespace someNameHere
    {
        public class MP3Player
        {
            private string Pcommand, FName,alias;
            private bool Opened, Playing, Paused, Loop,
                         MutedAll, MutedLeft, MutedRight;
            private int rVolume, lVolume, aVolume,
                        tVolume, bVolume, VolBalance;
            private ulong Lng;
            private long Err;
            private static int counter = 0;
            public static List<MP3Player> currentlyActive = new List<MP3Player>();
            public static List<MP3Player> lastFiveActive = new List<MP3Player>();
    
            [DllImport("winmm.dll")]
            private static extern long mciSendString(string strCommand,
                    StringBuilder strReturn, int iReturnLength,
                    IntPtr hwndCallback);
    
            public MP3Player()
            {
                Opened = false;
                Pcommand = "";
                FName = "";
                Playing = false;
                Paused = false;
                Loop = false;
                MutedAll = MutedLeft = MutedRight = false;
                rVolume = lVolume = aVolume =
                          tVolume = bVolume = 1000;
                Lng = 0;
                VolBalance = 0;
                Err = 0;
                counter++;
                alias = "alias" + counter.ToString();
                currentlyActive = cleanUpActive();
                currentlyActive.Add(this);
            }
    
             ~MP3Player()
            {
                currentlyActive.Remove(this);
            }
    
    
            private List<MP3Player> cleanUpActive()
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                cachedList = (from c in cachedList where c.AudioLength == c.CurrentPosition select c).ToList();
    
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.Stop();
                    eachSound.Close();
                }
    
                return (from c in currentlyActive where c.AudioLength != c.CurrentPosition select c).ToList();
            }
             
             public static void playRandomFromFolder(string relpath, bool checkIfInLast)
             {
                 try
                 {
                     string currentdir = Environment.CurrentDirectory;
                     string[] Files = Directory.GetFiles(currentdir + relpath);
                     Random randNum = new Random();
                     List<string> list_paths = (from c in lastFiveActive select c.FileName).ToList();
    
                     string randomFile = "";
                     int i = 0;
                     while (true)
                     {
                         int zufall = randNum.Next(0, Files.Length);
                         if (!list_paths.Contains(Files[zufall]) || i > 10)
                         {
                             randomFile = Files[zufall];
                             break;
                         }
    
                     }
    
                     MP3Player playIt = new MP3Player();
                     playIt.Open(randomFile);
                     playIt.Play();
                 }
                 catch (Exception err)
                 {
                   //  MessageBox.Show(err.Message);
                 }
    
             }
    
    
    
            #region AllActiveFunctions
             
            public static void stopAllActive()
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.Stop();
                }
    
            }
            public static void pauseAllActive()
            {
                foreach (MP3Player eachSound in currentlyActive)
                {
                    eachSound.Pause();
                }
    
            }
            public static void playAllActive()
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.Play();
                }
    
            }
            public static void setVolumeAllActive(int i)
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.VolumeAll = i;
                }
    
            }
            public static void setVolumeLeft(int i)
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.VolumeLeft = i;
                }
    
            }
            public static void setVolumeRight(int i)
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.VolumeRight = i;
                }
    
            }
            public static void setVolumeTreble(int i)
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.VolumeTreble = i;
                }
    
            }
            public static void setVolumeBass(int i)
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.VolumeBass = i;
                }
    
            }
    
            public static void setBalance(int i)
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                foreach (MP3Player eachSound in cachedList)
                {
                    eachSound.Balance = i;
                }
    
            }
    
            public static void stopLast()
            {
                List<MP3Player> cachedList = new List<MP3Player>(currentlyActive);
                cachedList.Last().Stop();
            }
            #endregion
    
            #region Volume
            public bool MuteAll
            {
                get
                {
                    return MutedAll;
                }
                set
                {
                    MutedAll = value;
                    if (MutedAll)
                    {
                        Pcommand = "setaudio " + alias + " off";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                    else
                    {
                        Pcommand = "setaudio " + alias + " on";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                }
    
            }
    
            public bool MuteLeft
            {
                get
                {
                    return MutedLeft;
                }
                set
                {
                    MutedLeft = value;
                    if (MutedLeft)
                    {
                        Pcommand = "setaudio " + alias + " left off";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                    else
                    {
                        Pcommand = "setaudio " + alias + " left on";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                }
    
            }
    
            public bool MuteRight
            {
                get
                {
                    return MutedRight;
                }
                set
                {
                    MutedRight = value;
                    if (MutedRight)
                    {
                        Pcommand = "setaudio " + alias + " right off";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                    else
                    {
                        Pcommand = "setaudio " + alias + " right on";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                }
    
            }
    
            public int VolumeAll
            {
                get
                {
                    return aVolume;
                }
                set
                {
                    if (Opened && (value >= 0 && value <= 1000))
                    {
                        aVolume = value;
                        Pcommand = String.Format("setaudio " + alias + "" +
                                   " volume to {0}", aVolume);
                        if ((Err = mciSendString(Pcommand, null, 0,
                                              IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                }
            }
    
            public int VolumeLeft
            {
                get
                {
                    return lVolume;
                }
                set
                {
                    if (Opened && (value >= 0 && value <= 1000))
                    {
                        lVolume = value;
                        Pcommand = String.Format("setaudio " + alias + "" +
                                   " left volume to {0}", lVolume);
                        if ((Err = mciSendString(Pcommand, null, 0,
                                               IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                }
            }
    
            public int VolumeRight
            {
                get
                {
                    return rVolume;
                }
                set
                {
                    if (Opened && (value >= 0 && value <= 1000))
                    {
                        rVolume = value;
                        Pcommand = String.Format("setaudio" +
                                   " " + alias + " right volume to {0}", rVolume);
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                }
            }
    
            public int VolumeTreble
            {
                get
                {
                    return tVolume;
                }
                set
                {
                    if (Opened && (value >= 0 && value <= 1000))
                    {
                        tVolume = value;
                        Pcommand = String.Format("setaudio " + alias + "" +
                                                 " treble to {0}", tVolume);
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                }
            }
    
            public int VolumeBass
            {
                get
                {
                    return bVolume;
                }
                set
                {
                    if (Opened && (value >= 0 && value <= 1000))
                    {
                        bVolume = value;
                        Pcommand = String.Format("setaudio " + alias + " bass to {0}",
                                                 bVolume);
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                    }
                }
            }
    
            public int Balance
            {
                get
                {
                    return VolBalance;
                }
                set
                {
                    if (Opened && (value >= -1000 && value <= 1000))
                    {
                        VolBalance = value;
                        if (value < 0)
                        {
                            Pcommand = "setaudio " + alias + " left volume to 1000";
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                            Pcommand = String.Format("setaudio " + alias + " right" +
                                                     " volume to {0}", 1000 + value);
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                        }
                        else
                        {
                            Pcommand = "setaudio " + alias + " right volume to 1000";
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                            Pcommand = String.Format("setaudio " + alias + "" +
                                       " left volume to {0}", 1000 - value);
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                        }
                    }
                }
            }
            #endregion
    
            #region Main Functions
    
            public string FileName
            {
                get
                {
                    return FName;
                }
            }
    
            public bool Looping
            {
                get
                {
                    return Loop;
                }
                set
                {
                    Loop = value;
                }
            }
    
            public void Seek(ulong Millisecs)
            {
                if (Opened && Millisecs <= Lng)
                {
                    if (Playing)
                    {
                        if (Paused)
                        {
                            Pcommand = String.Format("seek " + alias + " to {0}", Millisecs);
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                        }
                        else
                        {
                            Pcommand = String.Format("seek " + alias + " to {0}", Millisecs);
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                            Pcommand = "play " + alias + "";
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                        }
                    }
                }
            }
    
            private void CalculateLength()
            {
                StringBuilder str = new StringBuilder(128);
                mciSendString("status " + alias + " length", str, 128, IntPtr.Zero);
                Lng = Convert.ToUInt64(str.ToString());
            }
    
            public ulong AudioLength
            {
                get
                {
                    if (Opened) return Lng;
                    else return 0;
                }
            }
    
            public void Close()
            {
                if (Opened)
                {
                    Pcommand = "close " + alias + "";
                    if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        OnError(new ErrorEventArgs(Err));
                    Opened = false;
                    Playing = false;
                    Paused = false;
                    OnCloseFile(new CloseFileEventArgs());
                }
            }
    
            public void Open(string sFileName)
            {
                if (!Opened)
                {
                    Pcommand = "open \"" + sFileName +
                               "\" type mpegvideo alias " + alias + "";
                    if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        OnError(new ErrorEventArgs(Err));
                    FName = sFileName;
                    Opened = true;
                    Playing = false;
                    Paused = false;
                    Pcommand = "set " + alias + " time format milliseconds";
                    if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        OnError(new ErrorEventArgs(Err));
                    Pcommand = "set " + alias + " seek exactly on";
                    if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        OnError(new ErrorEventArgs(Err));
                    CalculateLength();
                    OnOpenFile(new OpenFileEventArgs(sFileName));
                }
                else
                {
                    this.Close();
                    this.Open(sFileName);
                }
            }
    
            private void stackLastFive(MP3Player latest)
            {
                if (lastFiveActive.Count() > 5)
                {
                  lastFiveActive.Reverse();
                  lastFiveActive = lastFiveActive.Take(4).ToList();
                }
                lastFiveActive.Add(latest);
    
            }
    
            public void Play()
            {
                if (Opened)
                {
                    if (!Playing)
                    {
                        Playing = true;
                        Pcommand = "play " + alias + "";
                        if (Loop) Pcommand += " REPEAT";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                        OnPlayFile(new PlayFileEventArgs());
                    }
                    else
                    {
                        if (!Paused)
                        {
                            Pcommand = "seek " + alias + " to start";
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                            Pcommand = "play " + alias + "";
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                            OnPlayFile(new PlayFileEventArgs());
                        }
                        else
                        {
                            Paused = false;
                            Pcommand = "play " + alias + "";
                            if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                                OnError(new ErrorEventArgs(Err));
                            OnPlayFile(new PlayFileEventArgs());
                        }
                    }
                    stackLastFive(this);
                }
            }
    
            public void Pause()
            {
                if (Opened)
                {
                    if (!Paused)
                    {
                        Paused = true;
                        Pcommand = "pause " + alias + "";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                        OnPauseFile(new PauseFileEventArgs());
                    }
                    else
                    {
                        Paused = false;
                        Pcommand = "play " + alias + "";
                        if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                        OnPlayFile(new PlayFileEventArgs());
                    }
                }
            }
    
            public void Stop()
            {
                if (Opened && Playing)
                {
                    Playing = false;
                    Paused = false;
                    Pcommand = "seek " + alias + " to start";
                    if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        OnError(new ErrorEventArgs(Err));
                    Pcommand = "stop " + alias + "";
                    if ((Err = mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        OnError(new ErrorEventArgs(Err));
                    currentlyActive.Remove(this);
                    OnStopFile(new StopFileEventArgs());
                }
            }
    
            public ulong CurrentPosition
            {
                get
                {
                    if (Opened && Playing)
                    {
                        StringBuilder s = new StringBuilder(128);
                        Pcommand = "status " + alias + " position";
                        if ((Err = mciSendString(Pcommand, s, 128, IntPtr.Zero)) != 0)
                            OnError(new ErrorEventArgs(Err));
                        return Convert.ToUInt64(s.ToString());
                    }
                    else return 0;
                }
            }
    
            #endregion
    
            #region Event Handling
    
            public delegate void OpenFileEventHandler(Object sender,
                                 OpenFileEventArgs oea);
    
            public delegate void PlayFileEventHandler(Object sender,
                                 PlayFileEventArgs pea);
    
            public delegate void PauseFileEventHandler(Object sender,
                                 PauseFileEventArgs paea);
    
            public delegate void StopFileEventHandler(Object sender,
                                             StopFileEventArgs sea);
    
            public delegate void CloseFileEventHandler(Object sender,
                                             CloseFileEventArgs cea);
    
            public delegate void ErrorEventHandler(Object sender,
                                             ErrorEventArgs eea);
    
            public event OpenFileEventHandler OpenFile;
    
            public event PlayFileEventHandler PlayFile;
    
            public event PauseFileEventHandler PauseFile;
    
            public event StopFileEventHandler StopFile;
    
            public event CloseFileEventHandler CloseFile;
    
            public event ErrorEventHandler Error;
    
            protected virtual void OnOpenFile(OpenFileEventArgs oea)
            {
                if (OpenFile != null) OpenFile(this, oea);
            }
    
            protected virtual void OnPlayFile(PlayFileEventArgs pea)
            {
                if (PlayFile != null) PlayFile(this, pea);
            }
    
            protected virtual void OnPauseFile(PauseFileEventArgs paea)
            {
                if (PauseFile != null) PauseFile(this, paea);
            }
    
            protected virtual void OnStopFile(StopFileEventArgs sea)
            {
                if (StopFile != null) StopFile(this, sea);
            }
    
            protected virtual void OnCloseFile(CloseFileEventArgs cea)
            {
                if (CloseFile != null) CloseFile(this, cea);
                if (currentlyActive.Contains(this))
                {
                    currentlyActive.Remove(this);
                }
            }
    
            protected virtual void OnError(ErrorEventArgs eea)
            {
                if (Error != null) Error(this, eea);
            }
    
            
        }
           
        public class OpenFileEventArgs : EventArgs
        {
            public OpenFileEventArgs(string filename)
            {
                this.FileName = filename;
            }
            public readonly string FileName;
        }
    
        public class PlayFileEventArgs : EventArgs
        {
            public PlayFileEventArgs()
            {
    
            }
        }
    
        public class PauseFileEventArgs : EventArgs
        {
            public PauseFileEventArgs()
            {
            }
        }
    
        public class StopFileEventArgs : EventArgs
        {
            public StopFileEventArgs()
            {
            }
        }
    
        public class CloseFileEventArgs : EventArgs
        {
            public CloseFileEventArgs()
            {
            }
        }
    
        public class ErrorEventArgs : EventArgs
        {
            public ErrorEventArgs(long Err)
            {
                this.ErrNum = Err;
            }
    
            public readonly long ErrNum;
        }
         #endregion
    }
