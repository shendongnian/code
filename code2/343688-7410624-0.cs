        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Data;
        using System.Windows.Documents;
        using System.Windows.Input;
        using System.Windows.Media;
        using System.Windows.Media.Imaging;
        using System.Windows.Navigation;
        using System.Windows.Shapes;
        using System.Windows.Media.Animation;
        using System.ComponentModel;
        using System.Threading;
        namespace WpfApplication6
        {
            public partial class MainWindow : Window
            {
                BackgroundWorker position = new BackgroundWorker();
                BackgroundWorker test_position = new BackgroundWorker();
                public List<video_script> script_list = new List<video_script>();
                int scrip_index;
        public class video_script
            {
            public string action { get; set; }
            public TimeSpan start_time { get; set; }
            public TimeSpan endtime { get; set; }
            public string filename { get; set; }
        }
        private void position_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
        }
        private void position_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          if (mediaElement1.Position > TimeSpan.FromMilliseconds(Convert.ToInt32(tb_endtime.Text)))
            {
                next_item();
            }
            else position.RunWorkerAsync();
            textBox4.Text = "Play";
            textBox3.Text = mediaElement1.Position.ToString();
        }
        public MainWindow()
        {
            InitializeComponent();
            position.DoWork += new DoWorkEventHandler(position_DoWork);
            position.RunWorkerCompleted += new RunWorkerCompletedEventHandler(position_RunWorkerCompleted);
            position.WorkerSupportsCancellation = true;
            test_position.DoWork += new DoWorkEventHandler(test_position_DoWork);
            test_position.RunWorkerCompleted += new RunWorkerCompletedEventHandler(test_position_RunWorkerCompleted);
            test_position.WorkerSupportsCancellation = true;
        }
        private void Mediasource_Click(object sender, RoutedEventArgs e)
        {
            if (!position.IsBusy) position.RunWorkerAsync();
            mediaElement1.Source = new Uri(tb_filename.Text);
            mediaElement1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            mediaElement1.UnloadedBehavior = System.Windows.Controls.MediaState.Manual;
            mediaElement1.ScrubbingEnabled = true;
            mediaElement1.Play();
        }
        private void stopbutton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }
        private void Playbutton_Click(object sender, RoutedEventArgs e)
        {
            scrip_index = 0;
            mediaElement1.Play();
            mediaElement1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            mediaElement1.UnloadedBehavior = System.Windows.Controls.MediaState.Manual;
            mediaElement1.ScrubbingEnabled = true;
        }
        private void pausebutton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement1.CanPause)
            {
                mediaElement1.Pause();
            }
        }
        private void AddToListbutton_Click(object sender, RoutedEventArgs e)
        {
            video_script temp_item = new video_script();
            temp_item.filename = tb_filename.Text;
            temp_item.start_time = TimeSpan.FromMilliseconds(Convert.ToInt32(tb_starttime.Text));
            temp_item.endtime = TimeSpan.FromMilliseconds(Convert.ToInt32(tb_endtime.Text));
            temp_item.action = tb_action.Text;
            script_list.Add(temp_item);
            listBox1.Items.Add(temp_item.filename + " | " + tb_starttime.Text + " | " + tb_endtime.Text + " | " + tb_action.Text);
        }
       
        private void positionbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (script_list.Count != 0)
            {
                if (script_list[scrip_index].endtime < mediaElement1.Position) next_item();
            }
        }
        #region test button area
        private void next_item()
        {
            if (scrip_index < script_list.Count() - 1)
            {
                scrip_index++; 
              
               
               
                switch (script_list[scrip_index].action)
                {
                    case "Load":
                       
                  mediaElement1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
                  mediaElement1.UnloadedBehavior = System.Windows.Controls.MediaState.Manual;
                  if (mediaElement1.Source != new Uri(script_list[scrip_index].filename)) mediaElement1.Source = new Uri(script_list[scrip_index].filename);
                  mediaElement1.ScrubbingEnabled = true;
                  playing = false;
                        next_item();
                        break;
                    case "Play":
                        mediaElement1.Play();
                        playing = true;
                        if(!test_position.IsBusy) test_position.RunWorkerAsync();
                       
                        break;
                    case "Pause":
                        mediaElement1.Pause();
                        playing = false;
                        break;
                    case "Seek":
                        mediaElement1.Position = script_list[scrip_index].start_time;
                        playing = true;
                        break;
                    case "Stop":
                        mediaElement1.Stop();
                        playing = false;
                        break;
                }
                
            }
        }
        private void test_position_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
        }
        private void test_position_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mediaElement1.Position > script_list[scrip_index].endtime )
            {
                next_item();
            }
            else test_position.RunWorkerAsync();
            
            textBox4.Text = "Play";
            textBox3.Text = mediaElement1.Position.ToString();
            if (playing && !test_position.IsBusy) test_position.RunWorkerAsync();
        }
        private void testbutton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement1.Source != new Uri(tb_filename.Text)) mediaElement1.Source = new Uri(tb_filename.Text);
                        mediaElement1.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            mediaElement1.UnloadedBehavior = System.Windows.Controls.MediaState.Manual;
            mediaElement1.Play();
            mediaElement1.ScrubbingEnabled = true;
            mediaElement1.Position = TimeSpan.FromMilliseconds(Convert.ToInt32(tb_starttime.Text));
            if (test_position.IsBusy) test_position.CancelAsync();
            if (!test_position.IsBusy) test_position.RunWorkerAsync();
        }
        bool playing;
        #endregion
        #region slider region
        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider1.Value > slider2.Value) slider2.Value = slider1.Value - 1;
        }
        private void slidermax_values_TextChanged(object sender, TextChangedEventArgs e)
        {
            slider1.Maximum = Convert.ToInt32(tb_slider_maxvalue.Text);
            slider2.Maximum = Convert.ToInt32(tb_slider_maxvalue.Text);
        }
        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider2.Value < slider1.Value) slider1.Value = slider2.Value - 1;
        }
        #endregion
        private void start_script_Click(object sender, RoutedEventArgs e)
        {
            scrip_index = -1;
            next_item(); 
        }
        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
          
        }
 
       }
    }
